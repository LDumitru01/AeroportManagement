export interface CreateTicketRequest {
  flightNumber: string;
  firstName: string;
  lastName: string;
  passportNumber: string;
  seat: number;
  mealOption: number;
  luggageWeight: number;
}

interface TicketValidator {
  setNext(handler: TicketValidator): TicketValidator;
  validate(request: CreateTicketRequest): string | null;
}

abstract class TicketValidatorBase implements TicketValidator {
  private nextHandler: TicketValidator | null = null;

  public setNext(handler: TicketValidator): TicketValidator {
    this.nextHandler = handler;
    return handler;
  }

  public validate(request: CreateTicketRequest): string | null {
    const result = this.handle(request);
    if (result) return result;
    if (this.nextHandler) {
      return this.nextHandler.validate(request);
    }
    return null;
  }

  protected abstract handle(request: CreateTicketRequest): string | null;
}

export class SeatValidator extends TicketValidatorBase {
  protected handle(request: CreateTicketRequest): string | null {
    return request.seat < 0 ? "Locul selectat este invalid." : null;
  }
}

export class LuggageValidator extends TicketValidatorBase {
  protected handle(request: CreateTicketRequest): string | null {
    return request.luggageWeight > 30
      ? "Greutatea bagajului depășește 30kg."
      : null;
  }
}

export class PassengerValidator extends TicketValidatorBase {
  protected handle(request: CreateTicketRequest): string | null {
    if (
      !request.firstName.trim() ||
      !request.lastName.trim() ||
      !request.passportNumber.trim()
    ) {
      return "Datele pasagerului sunt incomplete.";
    }
    return null;
  }
}
